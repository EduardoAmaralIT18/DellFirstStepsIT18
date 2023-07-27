<template>
  <div class="dds__select" data-dds="select">
      <div class="dds__select__wrapper">
        <label v-if="required" id="date-picker-label-206993451" for="date-picker-control-name-206993451"
            class="dds__label dds__label--required">{{ selectTitle }}</label>
        <label v-else id="select-label-293511350" for="select-control-293511350" class="dds__label">{{ selectTitle }}</label>
        <label id="select-label" for="select-label" class="dds__label">{{ boxName }}</label>
        <select id="select-control-505500786" v-model="selectedValue" @change="sendSelectedToParent" class="dds__select__field">
          <option class="dds__select__option--placeholder" disabled value="">{{ placeholder }}</option>
          <option
            v-for="item in list" 
            :value="item">
             {{item}} 
          </option>
        </select>
        <div id="select-error-505500786" class="dds__invalid-feedback">Error message</div>
      </div>
  </div>
</template>

<script setup lang="ts">

import {ref} from "vue";

const props = defineProps({
  list: Array<string>,
  selectValue: Function,
  selectTitle: String,
  required: Boolean,
  boxName: String,
  placeholder: String,
  initialValue: String
});

const emits = defineEmits({
  selectedValue: String
})

const selectedValue = ref<String>(`${props.initialValue ? props.initialValue : ''}`)

function sendSelectedToParent() {
  emits("selectedValue", selectedValue);
}


</script>

<style> .dds__label--required::after {
   color: #0672CB;
 }
</style>