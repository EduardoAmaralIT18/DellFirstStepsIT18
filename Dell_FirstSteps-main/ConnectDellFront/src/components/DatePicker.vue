

<template>
  <div class="dds__date-picker" data-dds="date-picker">
    <label id="date-picker-label-206993451" for="date-picker-control-name-206993451"
      class="dds__label dds__label--required">
      {{ boxName }}
    </label>
    <div class="dds__date-picker__wrapper">
      <input type="date" class="dds__date-picker__input" placeholder="Enter the date" required="true" maxlength="256"
        id="date-picker-control-206993451" name="date-picker-control-name-206993451"
        aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451" />
      <small id="date-picker-helper-206993451" class="dds__date-picker__helper">Please, use the format MM/DD/YYYY</small>
      <div id="date-picker-error-206993451" class="dds__date-picker__invalid-feedback">Invalid date</div>
    </div>
  </div>
</template>

<script setup lang="ts">
import "@dds/components/src/scss/dds-icons.scss";
var d = new Date();
d = new Date(d.getFullYear(), d.getMonth(), d.getDate())

const props = defineProps({
  boxName: String
});
</script>


