<template>

    <div class="container">
        <form data-dds="form" class="dds__form dds__container">
            <fieldset class="dds__form__section">
                <h2 class="title">Create Program</h2>

                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__input-text__container">
                            <label id="text-input-label-396765024" for="text-input-control-name-396765024">Program
                                Name <span> *</span></label>
                            <div class="dds__input-text__wrapper">
                                <input v-model="program.name" type="text" class="dds__input-text"
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

                
                <div class="dates dds__row">
                    <div class="dds__col--6 dds__col--sm-6">
                        <div>
                            <label for="startDate">Start date <span> *</span></label>
                            <input v-model="program.startDate" type="date" id="startDate" name="startDate">
                        </div>
                    </div>
                    <div class="dds__col--6 dds__col--sm-6">
                        <div>
                            <label for="endDate">End date</label>
                            <input v-model="program.endDate" type="date" id="endDate" name="endDate">
                        </div>
                    </div>
                </div>

                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__select" data-dds="select">
                            <label id="select-label-141366292" for="select-control-141366292">Members <span> *</span></label>
                            <div class="multiselec dds__select__wrapper">
                                <MultiSelect v-model="program.members"/>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="dds__row">
                    <div class="dds__col--12 dds__col--sm-12">
                        <div class="dds__text-area__container" data-dds="text-area">
                            <div class="dds__text-area__header">
                                <label id="text-area-label-980579425"
                                    for="text-area-control-980579425">Description <span> *</span></label>
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

    <ul>
        <li v-for="member in program.members" :key="member.id">{{ member }}</li>
    </ul>

</template>

<script lang="ts">
import MultiSelect from './MultipleSelect.vue';

type User = {
    id: number,
    name: string
}[];

interface Data {
    program: {
        name: string,
        members: null | User,
        description: string,
        startDate: string,
        endDate: string
    }
}

export default {
    components: {
        MultiSelect
    },
    data(): Data {
        return {
            program: {
                name: '',
                members: null,
                description: '',
                startDate: new Date().toISOString().slice(0,10),
                endDate: ''
            },

        }
    }
}
</script>

<style scoped>
body {
    font-family: 'Roboto', sans-serif;
}

.container {
    padding-top: 5%;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}

.title {
    color: #0063B8;
    margin-top: 10%;
    margin-bottom: 5%;
    font-size: 200%;
}

label {
    display: flex;
    text-align: left;
    margin-bottom: 10px
}

.submitbutton {
    margin-top: 30px;
    display: flex;
    float: right;
    width: 20%;
    font-size: 20px;
}
.multiselect {
    border-color: #7e7e7e;
    margin-bottom: 5px;
}

.multiselect-tag {
    background: #0672CB;
} 

.dates{
    display: flex;
}

span{
    margin-left: 4px;
    color: rgba(255, 0, 0, 0.658);
    font-weight: bold;
}
</style>