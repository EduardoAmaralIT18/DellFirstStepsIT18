<script setup lang="ts">
import type Program from "@/interfaces/Program";


defineProps<Program>()
</script>

<template>
  <div class="dds__card">
    <div class="dds__card__content">
      <div class="dds__card__header">
      <span class="dds__card__header__text">
        <h5 class="dds__card__header__title">{{ name }}</h5>
      </span>
      </div>
      <div class="dds__card__body">{{ description }}</div>
    </div>
    <RouterLink style="text-decoration: none" class="link" :to="isBasic ? `/program/${id}` : `/myProgram/${id}`">
      Learn more ➔
    </RouterLink>
  </div>
</template>

<style scoped>

.dds__card {
  box-shadow: rgba(0, 0, 0, 0.176) 0px 3px 8px;
  border-radius: 10px;
  display: block;
  width: 250px;
  height: 225px;
  position: relative;
}

.dds__card__content {
  padding: 20px;
  
}

.dds__card__header__title {
  font-size: 19px;
  color: #0672CB;
  text-align: left;
}

.dds__card__body {
  font-size: 15px;
  color: #0e0e0e;
  display: -webkit-box;
  -webkit-line-clamp: 4;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
  padding-top: 20px;
  text-align: left;
}

.link {
  position: absolute;
  left: 20px;
  bottom: 10px;
}

</style>