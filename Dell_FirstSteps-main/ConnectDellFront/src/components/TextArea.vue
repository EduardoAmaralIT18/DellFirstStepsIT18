<template>
    <div id="textarea-485602361" class="dds__text-area__container" data-dds="text-area">
        <div class="dds__text-area__header">
          <label id="text-area-label-867784391" for="text-area-control-867784391" class="dds__label dds__label--required">{{ boxName }}</label>
        </div>
        <div class="dds__text-area__wrapper">
          <textarea
            class="dds__text-area"
            name="text-area-control-name-867784391"
            id="text-area-control-867784391"
            aria-required="true"
            aria-labelledby="text-area-label-867784391 text-area-helper-867784391"
            required
          ></textarea>
          <small id="text-area-error-867784391" class="dds__invalid-feedback">Error text</small>
        </div>
      </div>
</template>
  
<script setup lang="ts">
const props = defineProps({
  boxName: String
});
</script>