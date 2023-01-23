<template>
    <div v-if="user != null" class="container">
        <div class="top">
            <h2>Add News</h2>
        </div>
        <div class="container2">
            <p>All fields marked with an (<span>*</span>) are required.</p>
            <br />
            <form data-dds="form" class="dds__form" enctype="multipart/form-data">
                <fieldset class="dds__form__section">
                    <div class="dds__row">
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="dds__input-text__container">
                                <div class="dds__text-area__header">
                                    <label id="text-input-label-332997731" for="text-input-control-332997731"
                                        class="dds__label dds__label--required">
                                        Title <span> *</span>
                                    </label>
                                </div>
                                <div class="dds__input-text__wrapper">
                                    <input type="text" id="text-input-control-332997731" class="dds__input-text"
                                        required="true" />
                                </div>
                            </div>
                        </div>
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="dds__text-area__container" data-dds="text-area">
                                <div class="dds__text-area__header">
                                    <label id="text-area-label-977404453" for="text-area-control-977404453"
                                        class="dds__label dds__label--required">
                                        Text <span> *</span>
                                    </label>
                                </div>
                                <div class="dds__text-area__wrapper">
                                    <textarea class="dds__text-area" id="text-area-control-977404453" rows="5" cols="33"
                                        required="true"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="dds__col--1 dds__col--sm-3">
                            <div class="dds__file-input" data-dds="file-input" role="group"
                                aria-labelledby="file-input-label-795580561">
                                <label id="file-input-label-795580561" class="dds__label"
                                    for="file-input-control-name-795580561">Image </label>
                                <small id="file-input-helper-795580561" class="dds__file-input__helper-text"> Limit 2MB
                                    - PNG or JPG accepted.</small>
                                <input type="file" id="image"
                                    name="profile_pic" accept=".jpg, .jpeg, .png" />
                            </div>
                        </div>
                    </div>
                </fieldset>
                <button class="dds__button dds__button--lg" type="submit">Add Content</button>
            </form>
        </div>
    </div>
</template>
<script lang="ts">
/* eslint-disable */
import { defineComponent } from 'vue';
import axios from 'axios';

type News = {
}[];

interface Data {
    user: number | null,
    role: number,
}

export default defineComponent({
    data(): Data {
        return {
            user: null,
            role: 5,
        };
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

        },
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
    width: 65%;
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
</style>