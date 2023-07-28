<script setup lang="ts">
import "@dds/components/src/scss/dds-icons.scss";
import { ref } from "vue";

const info = ref<Date>()
const preset = ref<String>(new Date().toISOString().slice(0, 10))

defineProps({
    boxName: String,
    required: Boolean,
    dateNow: Boolean,
    minRequired: Boolean
})

const emits = defineEmits(['selectedDate'])

const sendStartToParent = () => {
    emits('selectedDate', preset.value)
}

const sendEndToParent = () => {
    emits('selectedDate', info.value)
}

</script>

<template>
    <div class="dds__date-picker" data-dds="date-picker" id="startPicker">
        <label v-if="required" id="date-picker-label-206993451" for="date-picker-control-name-206993451"
            class="dds__label dds__label--required">{{ boxName }}</label>
        <label v-else id="date-picker-label-206993451" for="date-picker-control-name-206993451"
            class="dds__label dds__label">{{ boxName }}</label>
        <div class="dds__date-picker__wrapper">
            <input v-if="dateNow" type="date" class="dds__date-picker__input" placeholder="Enter the date" required="true" maxlength="256"
                id="date-picker-control-206993451" name="date-picker-control-name-206993451"
                aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451" v-model= "preset"
                @input="sendStartToParent"/>
            <input v-else type="date" class="dds__date-picker__input" placeholder="Enter the date" required="true" maxlength="256"
                id="date-picker-control-206993451" name="date-picker-control-name-206993451"
                aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451" v-model="info"
                @input="sendEndToParent" :min="minRequired ? +preset! : undefined"/>
            <small id="date-picker-helper-206993451" class="dds__date-picker__helper">Please, use the format
                MM/DD/YYYY</small>
            <div id="date-picker-error-206993451" class="dds__date-picker__invalid-feedback">Invalid date</div>
        </div>
    </div>
</template>

<style scoped>
</style>
