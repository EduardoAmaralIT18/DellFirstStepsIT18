<template>
  <div class="dds__select" data-dds="select">
      <div class="dds__select__wrapper">
        <select id="select-control-505500786" v-model="value" @change="handleChange" class="dds__select__field">
          <!-- <option disabled value="">Please select user</option> -->
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
import { ref, defineEmits } from "vue";
  defineProps({
    list: Array<string>,
    selectValue: Function,
  });

  const selectedOption = ref("");
  // const { emit } = defineEmits();

  
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


