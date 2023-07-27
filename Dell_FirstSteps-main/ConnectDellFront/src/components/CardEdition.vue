<script setup lang="ts">
import type Edition from "@/interfaces/Edition";

function dateCompare(start: string, end: string) {
  const startDate: Date = new Date(start);
  const endDate: Date = new Date(end);
  const today: Date = new Date();

  if (startDate > today) {
    return "Not Started";
  }
  if (endDate < today) {
    return "Finished";
  }
  if (startDate <= today && endDate >= today) {
    return "Ongoing";
  }
  return "Error";
}

defineProps<Edition>();
</script>

<template>
  <div class="dds__card">
    <div class="dds__card__content">
      <div class="dds__card__header">
        <span class="dds__card__header__text">
          <h5 class="dds__card__header__title">{{ name }}</h5>
        </span>
        <span class="dds__badge dds__badge--brand dds__badge--light">
          <span class="dds__badge__label"
            >{{ dateCompare(startDate.toString(), endDate.toString()) }}
          </span>
        </span>
      </div>
      <div class="dds__card__body">{{ description }}</div>
    </div>
    <RouterLink
      style="text-decoration: none"
      class="link"
      :to="`/edition/${id}`"
    >
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
  color: #0672cb;
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
