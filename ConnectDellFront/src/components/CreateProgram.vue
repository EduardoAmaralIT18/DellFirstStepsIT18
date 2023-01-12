<template>

    <div class="container">
        <form data-dds="form" class="dds__form dds__container">
            <fieldset class="dds__form__section">
                <h2 class="title">Create Program</h2>
                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__input-text__container">
                            <label id="text-input-label-396765024" for="text-input-control-name-396765024">Program Name</label>
                            <div class="dds__input-text__wrapper">
                                <input v-model="form.name" type="text" class="dds__input-text"
                                    name="text-input-control-name-396765024" id="text-input-control-396765024"
                                    aria-labelledby="text-input-label-396765024 text-input-helper-396765024"
                                    required="true" />

                                <small id="text-input-helper-396765024" class="dds__input-text__helper"></small>
                                <div id="text-input-error-396765024" class="dds__invalid-feedback">Enter a program name
                                    to continue</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__select" data-dds="select">
                            <label id="select-label-141366292" for="select-control-141366292">Members</label>
                            <div class="dds__select__wrapper">
                                <select id="select-control-141366292" class="dds__select__field"
                                    aria-describedby="select-helper-141366292" required="true">
                                    <option value="" class="dds__select__option--placeholder" selected>Select an option
                                    </option>
                                    <option value="undefined">Tassia</option>
                                    <option value="undefined">Nelson</option>
                                </select>
                                <small id="select-helper-141366292" class="dds__select__helper"></small>
                                <div id="select-error-141366292" class="dds__invalid-feedback"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__select" data-dds="select">
                            <label id="select-label-484037542" for="select-control-484037542">Role</label>
                            <div class="dds__select__wrapper">
                                <select id="select-control-484037542" class="dds__select__field"
                                    aria-describedby="select-helper-484037542" required="true">
                                    <option value="" class="dds__select__option--placeholder" selected>Select an option
                                    </option>
                                    <option value="content">Content</option>
                                    <option value="design">Design</option>
                                    <option value="engineering">Engineering</option>
                                    <option value="product-management">Product management</option>
                                </select>
                                <small id="select-helper-484037542" class="dds__select__helper"></small>
                                <div id="select-error-484037542" class="dds__invalid-feedback"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__text-area__container" data-dds="text-area">
                            <div class="dds__text-area__header">
                                <label id="text-area-label-980579425"
                                    for="text-area-control-980579425">Description:</label>
                            </div>
                            <div class="dds__text-area__wrapper">
                                <textarea class="dds__text-area" name="text-area-control-name-980579425"
                                    id="text-area-control-980579425" data-maxlength="null" required="true"
                                    aria-labelledby="text-area-label-980579425 text-area-helper-980579425"></textarea>
                                <small id="text-area-helper-980579425" class="dds__input-text__helper"></small>
                                <small id="text-area-error-980579425" class="dds__invalid-feedback">Enter a description
                                    to continue</small>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
            <button class="submitbutton dds__button dds__button--lg" type="submit">Submit</button>
        </form>
    </div>


    <p>{{ form.name }}</p>
</template>

<script lang="ts">


export default {
    data() {
        return {
            form: {
                name: '',
                members: '',
                description: '',
                startDate: '',
                endDate: ''
            }

        }
    },
    methods: {

    }
}
</script>

<style scoped>
body{
    font-family: 'Roboto', sans-serif;
}
.container {
    padding-top: 5%;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}
.title{
  color: #0063B8;
  margin-top: 10%;
  margin-bottom: 5%;
  font-size: 200%;
}
label{
    display: flex;
   text-align: left; 
   margin-bottom: 10px
}
.submitbutton{
    margin-top: 30px;
    display: flex;
    float: right;
    width: 20%;
    font-size: 20px;
}
</style>