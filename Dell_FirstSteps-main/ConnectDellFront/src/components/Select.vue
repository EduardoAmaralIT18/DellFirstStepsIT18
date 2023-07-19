<script setup lang="ts">

defineProps<{list: String[]}>()
</script>


<template>
<div class="dds__select" data-dds="select">
    <label id="select-label-505500786" for="select-control-505500786" class="dds__label">Select label</label>
    <div class="dds__select__wrapper">
      <select v-for="item in list" id="select-control-505500786" class="dds__select__field">
        <option>{{item}}</option>
      </select>
      <div id="select-error-505500786" class="dds__invalid-feedback">Error message</div>
    </div>
</div>
</template>