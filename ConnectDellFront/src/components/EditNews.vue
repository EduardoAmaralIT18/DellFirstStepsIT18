<template>
    <div v-if="role == 0" class="container">
        <div class="top">
            <RouterLink to="/news" class="goBack"> &larr; Go back</RouterLink>
            <h2>Manage News</h2>
        </div>
        <div class="container2">
            <form data-dds="form" class="dds__form" enctype="multipart/form-data">
                <fieldset class="dds__form__section">
                    <div class="dds__row">
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="dds__select" data-dds="select">
                                <div class="dds__text-area__header">
                                    <label id="text-input-label-332997731" for="program.id"
                                        class="dds__label dds__label--required">
                                        Program <span> *</span>
                                    </label>
                                    <small v-if="v$.program.id.$error" class="help-block">The Program field is
                                        required</small>
                                </div>
                                <div class="dds__select__wrapper">
                                    <select :value="0" v-model="v$.program.id.$model" id="program.id"
                                        class="dds__select__field" aria-describedby="select-helper-374041805"
                                        required="true">
                                        <option :value="0" selected>Select</option>
                                        <option v-for="item in programs" :value="item.id" :key="item.id">
                                            {{ item.name }}
                                        </option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="dds__input-text__container">
                                <div class="dds__text-area__header">
                                    <label id="text-input-label-332997731" for="title"
                                        class="dds__label dds__label--required">
                                        Title <span> *</span>
                                    </label>
                                    <small v-if="v$.title.$error" class="help-block">The Title field is required</small>
                                </div>
                                <div class="dds__input-text__wrapper">
                                    <input type="text" v-model="v$.title.$model" id="title" name="title"
                                        class="dds__input-text" required="true" />
                                </div>
                            </div>
                        </div>
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="dds__text-area__container" data-dds="text-area">
                                <div class="dds__text-area__header">
                                    <label id="text-area-label-977404453" for="text"
                                        class="dds__label dds__label--required">
                                        Text <span> *</span>
                                    </label>
                                    <small v-if="v$.text.$error" class="help-block">The Text field is required</small>
                                </div>
                                <div class="dds__text-area__wrapper">
                                    <textarea class="dds__text-area" name="text" v-model="v$.text.$model" id="text"
                                        rows="5" cols="33" required="true"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="imageStyle dds__file-input" data-dds="file-input" role="group"
                                aria-labelledby="file-input-label-795580561">
                                <label id="file-input-label-795580561" class="dds__label" for="image">Image </label>
                                <small id="file-input-helper-795580561" class="dds__file-input__helper-text"> Limit 2MB
                                    - PNG or JPG accepted.</small>
                                <input type="file" id="image" @change="updateImage($event)" name="image"
                                    accept=".jpg, .jpeg, .png" />
                            </div>
                        </div>
                    </div>
                </fieldset>
                <button class="submitbutton dds__button dds__button--lg" type="submit" @click.prevent="addContent" :disabled="v$.$invalid">Submit</button>
            </form>
        </div>
    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import axios from 'axios';
import FormData from 'form-data';
import { useVuelidate } from '@vuelidate/core';
import { required, maxValue, minValue } from '@vuelidate/validators';

type Image = {
}[];

type Program = {
    id: Number; name: string;
}[];

interface Data {
    user: number | null,
    role: number,
    data: FormData | undefined,
    title: string,
    text: string,
    image: Image | null,
    programs: null | Program,
    program: { id: Number; name: string; },
    imageSize: number;
}

export default defineComponent({
    setup() {
        return { v$: useVuelidate() }
    },
    data(): Data {
        return {
            user: null,
            role: 5,
            data: new FormData(),
            title: "",
            text: "",
            image: null,
            programs: null,
            program: { id: 0, name: "", },
            imageSize: 0,
        };
    },
    validations() {
        return {
            program: { id: { required, minValue: minValue(1) } },
            title: { required },
            text: { required },
            imageSize: { maxValue: maxValue(2097152) },
        }
    },
    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData',
    },
    methods: {
        fetchData(): void {
            this.role = this.$cookies.get("role");
            this.user = this.$cookies.get("id");

            axios.get('/Program/GetPrograms', {
                params: {
                    idUser: this.user,
                    role: this.role,
                }
            })
                .then(function (response) {
                    return response;
                }).then(response => {
                    if (response.status == 404) { this.programs = []; }
                    else if (response.status == 200) { this.programs = response.data?.myPrograms; }
                    else { console.log(response.status); }
                })
        },
        addContent(): void {
            if (!this.v$.$invalid) {
                var program = this.programs?.find(prog => prog.id == this.program.id);

                this.data?.append('author', this.user);
                this.data?.append('program', program?.id);
                this.data?.append('title', this.title);
                this.data?.append('text', this.text);
                this.data?.append('imageName', this.title);
                this.data?.append('image', this.image);

                axios.post('news/addContent', this.data, {
                    headers: {
                        'accept': 'application/json',
                        'Content-Type': 'multipart/form-data'
                    }
                }).then(function (response) {
                    return response;
                }).then(response => {
                    if (response.status == 200) {
                        alert("Content added!");
                        this.$router.push({ name: 'NewsPage' });
                    } else if (response.status == 404) {
                        alert("Database error! Please try again later");
                    } else {
                        console.log(response.status);
                    }
                })
            } else {
                this.v$.$validate();
            }
        },

        updateImage(e: any): void {
            this.image = e.target.files[0];
            this.imageSize = e.target.files[0].size;
        }
    },
});
</script>
<style scoped>
h2 {
    color: #0672CB;

}

.top {
    padding-bottom: 3%;
}

.container {
    padding-top: 5%;
    padding-bottom: 50vh;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}

.container2 {
    width: 80%;
    align-self: center;
}

form {
    width: 100%;
}

span {
    margin-left: 4px;
    margin-right: 4px;
    color: #0063B8;
    font-weight: bold;
}

button {
    margin-top: 5%;
}

.dds__file-input {
    margin-top: 3%;
}

label {
    margin-top: 7px;
    width: 50%;
    display: flex;
    text-align: left;
}

.imageStyle {
    width: 100%;
}

.imageStyle small {
    display: flex;
}

.imageStyle input {
    display: flex;
    margin-top: 8px;
}

button {
    margin-top: 30px;
}
small{
    color: red;
}
.goBack {
  position: relative;
  right: 40%;
  text-decoration: none;
  color: #0672CB;
  font-weight: 300;
}
.warning {
    display: flex;
    margin-top: 31px;
    margin-bottom: -3px;
}

.submitbutton {
    display: flex;
    float: left;
}
</style>