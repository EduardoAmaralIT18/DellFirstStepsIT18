<template>
  <div class="dds__select" data-dds="select">
    <label v-if="required" id="date-picker-label-206993451" for="date-picker-control-name-206993451"
            class="dds__label dds__label--required">{{ selectTitle }}</label>
    <label v-else id="select-label-293511350" for="select-control-293511350" class="dds__label">{{ selectTitle }}</label>
      <div class="dds__select__wrapper">
        <select id="select-control-505500786" v-model="value" @change="handleChange" class="dds__select__field">
          <option disabled value="Please select user">Please select user</option>
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
import { ref } from "vue";
  defineProps({
    list: Array<string>,
    selectValue: Function,
    selectTitle: String,
    required: Boolean,
  });

  const selectedOption = ref("");

  
</script>

<script lang="ts">
  export default {
    data() {
      return {
        value: "Please select user",
      };
    },
    methods: {
      handleChange() {
        this.$emit("selectValue", this.value);
      }
    },
  };
</script>

<style> 
.dds__label--required::after {  
    color: #0672CB;
}
</style>