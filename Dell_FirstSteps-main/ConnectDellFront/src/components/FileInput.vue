<script setup lang="ts">
import { ref } from 'vue';
import "@/components/FileInput.vue";

const selectedFile = ref<File>();

// const imageName = ref<string>();
defineProps({
  imageName: String
})
const fileInput = ref(null);

// @ts-ignore
const emits = defineEmits({
  selectedFile: File
})

const onFileChange = (event: Event) => {
  selectedFile.value = (event.target as HTMLInputElement)?.files![0];
  emits('fileSelected', selectedFile.value);
}
</script>

<template>
  <div class="dds__file-input" data-dds="file-input">
    <label id="file-input-label-861422857" class="dds__file-input__label" for="file-input-control-name-861422857">Image</label>
    <small id="file-input-helper-861422857" class="dds__file-input__helper-text">{{imageName}}</small>
    <input
        aria-hidden="true"
        id="file-input-control-861422857"
        type="file"
        name="file-input-control-name-861422857"
        class="dds__file-input__control"
        accept=".png, .jpeg, .jpg"
        ref="fileInputRef"
        @change="onFileChange"
    />
    <button
        type="button"
        class="dds__button dds__button--secondary dds__button--md dds__file-input__button"
        aria-describedby="file-input-label-861422857 file-input-helper-861422857"
        @click="openFileInput"
    >
      <i class="dds__icon dds__icon--upload" aria-hidden="true"></i>
      Browse Files
    </button>
    <div id="file-input-error-861422857" aria-live="polite" class="dds__error-text">
      <i class="dds__icon dds__icon--alert-notice dds__error-text__icon" aria-hidden="true"></i>
      Error Text
    </div>
  </div>



</template>

<script lang="ts">
export default {
  methods: {
    openFileInput: function () {
      this.$refs.fileInputRef.click();
    },
  },
};
</script>

<style scoped>
button {
  gap: 10px;
  display: flex;
  align-items: center;
  justify-content: center;
}

img {
  filter: invert(100%)
}
</style>