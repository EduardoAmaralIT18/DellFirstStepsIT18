<template>
  <div class="dds__select" data-dds="select">
      <div class="dds__select__wrapper">
        <select id="select-control-505500786" class="dds__select__field">
          <option disabled value="">Please select one</option>
          <option v-for="item in list" :value="item" :key="item">{{item}}</option>
        </select>
        <div id="select-error-505500786" class="dds__invalid-feedback">Error message</div>
      </div>
  </div>
  </template>

<script setup lang="ts">
import { ref } from "vue";

defineProps({list: String})
</script>


