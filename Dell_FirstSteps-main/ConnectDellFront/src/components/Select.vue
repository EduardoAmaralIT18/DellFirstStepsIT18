<template>
  <div class="dds__select" data-dds="select">
      <div class="dds__select__wrapper">
        <label id="select-label" for="select-label" class="dds__label">{{ boxName }}</label>
        <select id="select-control-505500786" v-model="selectedValue" @change="sendSelectedToParent" class="dds__select__field">
          <option disabled value="">{{ placeholder }}</option>
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

let selectedValue: string = '';

const emits = defineEmits({
  selectedValue: String
})

defineProps({
  list: Array<string>,
  boxName: String,
  placeholder: String
});

function sendSelectedToParent() {
  emits("selectedValue", selectedValue);
}


</script>


