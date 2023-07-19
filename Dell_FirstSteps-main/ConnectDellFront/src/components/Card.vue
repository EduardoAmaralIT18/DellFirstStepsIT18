<script setup lang="ts">
import type Program from "@/interfaces/Program";

defineProps<Program>()
</script>

<template>
  <div class="dds__card">
    <div class="dds__card__content">
      <div class="dds__card__header">
      <span class="dds__card__header__text">
        <h5 class="dds__card__header__title">{{name}}</h5>
      </span>
      </div>
      <div class="dds__card__body">{{description}}</div>
      <div class="dds__card__footer">
        <RouterLink style="text-decoration: none" class="link" to="/programinfo">
          Learn more ➔
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<style>
</style>

