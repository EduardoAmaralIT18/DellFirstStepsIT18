<template>
    <div class="dds__empty-state__icon">
        <span class="dds__icon dds__icon--alert-notice"></span>
        <span class="dds__sr-only">Notice</span>
    </div>
    <h1 class="dds__empty-state__title">Page not found.</h1>
    <div class="dds__empty-state__description">
                <div class="dds__empty-state__action">
            <button class="dds__button dds__button--mini dds__button--primary" type="button" @click="returnHome()">Return to Home</button>
        </div>
    </div>
</template>

<script lang="ts">

import { defineComponent } from "vue"; //trago do vue essa funcao defineComponent
export default defineComponent({ //exportando

methods: {
    returnHome(): void {
      this.$router.push({ name: "HomePage" });
    },
  },
})
</script>