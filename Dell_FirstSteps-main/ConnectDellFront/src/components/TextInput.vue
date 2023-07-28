<script setup lang="ts">
import {ref} from "vue";

const props = defineProps({
  boxName: String,
  minlength: String,
  maxlength: String,
  initialValue: String
})

const info = ref<String>(`${props.initialValue ? props.initialValue : ''}`)

const emits = defineEmits({
  typedText: String
})

const sendTextToParent = (text: string) => {
  info.value = text;
  emits("typedText", info.value);
}
</script>

<template>
  <div id="text-input-216225955" class="dds__input-text__container">
    <label id="text-input-label-647192958" for="text-input-control-647192958" class="dds__label dds__label--required">{{ boxName }}</label>
    <div class="dds__input-text__wrapper">
      <input :minlength="`${minlength}`" :maxlength="`${maxlength}`" type="text" class="dds__input-text" name="text-input-control-name-647192958"
             id="text-input-control-647192958" required="true"
             aria-labelledby="text-input-label-647192958 text-input-helper-647192958" v-model="info"
             @input="sendTextToParent(info)" />
      <small id="text-input-helper-647192958" class="dds__input-text__helper"></small>
      <div id="text-input-error-647192958" class="dds__invalid-feedback">Error text</div>
    </div>
  </div>
</template>

<style scoped>
.dds__label--required::after {
  color: #0672CB;
}
</style>