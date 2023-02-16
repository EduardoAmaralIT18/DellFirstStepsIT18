<template>
    <div class="container">
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
                                    <label id="text-input-label-332997731" for="programId"
                                        class="dds__label dds__label--required">
                                        Program <span> *</span>
                                    </label>
                                    <small v-if="v$.news.programId.$error" class="help-block">The Program field is
                                        required</small>
                                </div>
                                <div class="dds__select__wrapper">
                                    <select :value="0" v-model="v$.news.programId.$model" id="programId"
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
                                    <small v-if="v$.news.title.$error" class="help-block">The Title field is
                                        required</small>
                                </div>
                                <div class="dds__input-text__wrapper">
                                    <input type="text" v-model="v$.news.title.$model" id="title" name="title"
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
                                    <small v-if="v$.news.text.$error" class="help-block">The Text field is
                                        required</small>
                                </div>
                                <div class="dds__text-area__wrapper">
                                    <textarea class="dds__text-area" name="text" v-model="v$.news.text.$model" id="text"
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
                <button class="submitbutton dds__button dds__button--lg" type="submit" @click.prevent="onSubmit"
                    :disabled="v$.$invalid">Submit</button>
            </form>
        </div>
    </div>
    <div role="dialog" data-dds="modal" class="dds__modal" id="modalId" ref="modalId">
        <div class="dds__modal--md" @ddsModalClosedEvent="navigateToParent">
            <div class="dds__modal__content">
                <div class="dds__modal__header">
                    <h3 class="dds__modal__title" id="modal-headline-369536123">{{ modalTitle }}</h3>
                </div>
                <div id="modal-body-532887773" class="dds__modal__body">
                    <p class="modalMessage">
                        {{ modalMessage }}
                    </p>
                </div>
                <div class="dds__modal__footer">
                    <button class="buttonModal dds__button dds__button--block"
                        v-bind:class="modalSuccess ? '' : 'dds__button--destructive'" type="button"
                        name="modal-secondary-button" @click.prevent="navigateToParent">OK</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import axios from 'axios';
import FormData from 'form-data';
import { useVuelidate } from '@vuelidate/core';
import { required, maxValue, minValue } from '@vuelidate/validators';
declare var DDS: any;

type Image = {
}[];

type Program = {
    id: Number;
    name: string;
}[];

interface Data {
    news: {
        id: number | null;
        programId: number;
        title: string;
        text: string;
        image: Image | null;
        imageSize: number;

    };
    user: number;
    programs: null | Program;
    modalMessage: string;
    modalTitle: string;
    modalSuccess: boolean;
    idNews: any;
}

export default defineComponent({
    setup() {
        return { v$: useVuelidate() }
    },
    data(): Data {
        return {
            news: {
                id: null,
                programId: 0,
                title: "",
                text: "",
                image: null,
                imageSize: 0
            },
            user: 0,
            programs: null,
            modalMessage: "",
            modalTitle: "",
            modalSuccess: false,
            idNews: this.$route.params.idNews
        };
    },
    validations() {
        return {
            news: {
                programId: { required, minValue: minValue(1) },
                title: { required },
                text: { required },
                imageSize: { maxValue: maxValue(2097152) }
            }
        }
    },
    mounted() {
        this.user = this.$cookies.get("id");
        this.getPrograms();
        this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData',
    },
    methods: {
        fetchData(): void {
            axios
                .get(`/News/getSpecificNews?id=${this.idNews}`)
                .then(function (response) {
                    return response;
                })
                .then(response => {
                    if (response.status == 200) {
                        this.news = response.data;
                    } else {
                        const element = this.$refs.modalId;
                        const modal = new DDS.Modal(element);
                        this.modalTitle = "Error";
                        this.modalMessage = "I'm sorry, something went wrong. Try again later."
                        this.modalSuccess = false;
                        modal.open();
                    }
                })
        },
        getPrograms(): void {
            let role = this.$cookies.get("role");
            axios.get('/Program/GetPrograms', {
                params: {
                    idUser: this.user,
                    role: role,
                }
            }).then(function (response) {
                return response;
            }).then(response => {
                if (response.status == 404) { this.programs = []; }
                else if (response.status == 200) { this.programs = response.data?.myPrograms; }
                else { console.log(response.status); }
            })
        },
        onSubmit(): void {
            if (!this.v$.$invalid) {
                const element = this.$refs.modalId;
                const modal = new DDS.Modal(element);

                let data = new FormData();
                data.append('id', this.news.id);
                data.append('author', this.user);
                data.append('program', this.news.programId);
                data.append('title', this.news.title);
                data.append('text', this.news.text);
                data.append('imageName', this.news.title);
                data.append('image', this.news.image);

                axios.post('/News/UpdateNews', data, {
                    headers: {
                        'accept': 'application/json',
                        'Content-Type': 'multipart/form-data'
                    }
                }).then(function (response) {
                    return response;
                }).then(response => {
                    if (response.status == 200) {
                        this.modalTitle = "News Edited";
                        this.modalMessage = "Your news was successfully edited."
                        this.modalSuccess = true;
                    } else {
                        this.modalTitle = "Error";
                        this.modalMessage = "I'm sorry, something went wrong. Try again later."
                        this.modalSuccess = false;
                    }
                    modal.open();
                })
            } else {
                this.v$.$validate();
            }
        },
        updateImage(e: any): void {
            this.news.image = e.target.files[0];
            this.news.imageSize = e.target.files[0].size;
        },
        navigateToParent(): void {
            this.$router.push({ name: 'NewsPage' });
        }
    }
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

small {
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
    margin-top: 30px;
}

.modalMessage {
    text-align: left;
    margin-bottom: 10px;
}

.dds__modal--md {
    width: 400px;
}
</style>