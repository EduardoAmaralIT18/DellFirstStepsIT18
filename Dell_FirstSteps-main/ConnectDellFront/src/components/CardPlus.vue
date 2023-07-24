<script setup lang="ts">
import {RouterLink} from 'vue-router';

defineProps<{ url: string }>()
</script>

<template>
  <div class="dds__card">
    <div class="dds__card__content">
      <div class="addProgramIcon dds__card__body">
        <RouterLink style="text-decoration: none" :to="`${url}`">
          +
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<style scoped>
.dds__card {
  box-shadow: rgba(0, 0, 0, 0.176) 0px 3px 8px;
  border-radius: 10px;
  display: block;
  width: 250px;
  height: 225px;
}

.dds__card__content {
  padding: 20px;
}

.addProgramIcon {
  color: #0672CB;
  text-align: center;
  font-size: 89px;
  padding-top: 40%;
  padding-bottom: 35px;
  text-decoration: none;
}
</style>

