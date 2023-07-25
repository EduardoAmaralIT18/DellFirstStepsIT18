<template>
    <!-- <button @click="modal.open()" class="button" id="example" type="button">Launch Modal Button</button> -->
    <div role="dialog" ref="list" data-dds="modal" class="dds__modal" aria-labelledby="modal-headline-160350263">
      <div class="dds__modal__content">
        <div @OnClick="closeModal" class="dds__modal__header"><h3 class="dds__modal__title" id="modal-headline-160350263">{{ props.event?.name }}</h3></div>
        <div id="modal-body-754450445" class="dds__modal__body">
          <b>EventType: </b><p>{{ EventType[props.event?.eventType as number] }}</p>
          <b>Start Date: </b><p>{{ props.event?.startDate }}</p>
          <b>End Date: </b><p>{{ props.event?.endDate }}</p>
          <b>Where: </b><p>{{ props.event?.where }}</p>
        </div>
        <div class="dds__modal__footer">
          <button class="dds__button dds__button--secondary dds__button--md" type="button" name="modal-primary-button">No</button>
          <button @OnClick="closeModal" class="dds__button dds__button--md" type="button" name="modal-secondary-button">Yes</button>
        </div>
      </div>
    </div>
    </template>
<script setup lang="ts">
  import { onMounted, ref, PropType } from 'vue';
  import TypeEvent from "../interfaces/Event"

  enum PhaseType {
  "Setup",
  "Training",
  "Sprints",
  "HandsOn"
  }

  enum EventType {
    "Phase",
    "Activity"
  }

  const props = defineProps({
    event : Object as PropType<TypeEvent>,
  });
  declare var DDS: any;
  const modal= ref()
  const list = ref(null)
    
  function closeModal() {
    modal.value.close()
  }

  onMounted(() => {
      modal.value = DDS.Modal(list.value);
      modal.value.open();
    }
  )
</script>
<style scoped>

</style>    