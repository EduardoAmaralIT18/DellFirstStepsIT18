<script setup lang="ts">

import type User from "@/interfaces/User";
import axios from "axios";
import type PopupParam from "@/interfaces/PopupParam";

defineProps<PopupParam>()

</script>

<template>
  <div role="dialog" data-dds="modal" data-trigger="#example" aria-labelledby="modal-headline-571703243">
    <div class="dds__modal__content">
      <div class="dds__modal__header"><h3 class="dds__modal__title" id="modal-headline-571703243">{{ title }}</h3></div>
      <div id="modal-body-100951590" class="dds__modal__body">
        <p>{{ text }}</p>
        <br>
        <p>Are you sure that you want to proceed?</p>
      </div>
      <div class="dds__modal__footer">
        <button class="dds__button dds__button--secondary dds__button--md" type="button" name="modal-primary-button">
          No
        </button>
        <button @click="action()" class="dds__button dds__button--md" type="button" name="modal-secondary-button">Yes
        </button>
      </div>
    </div>
  </div>

</template>

<style scoped>

</style>