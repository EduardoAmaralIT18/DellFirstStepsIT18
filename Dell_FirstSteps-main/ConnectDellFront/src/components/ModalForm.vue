<template>
<button @click="modal.open()" class="dds__button" id="example" type="button">Launch Modal Button</button>
<div role="dialog" ref="list" data-dds="modal" class="dds__modal" aria-labelledby="modal-headline-160350263">
  <div class="dds__modal__content">
    <div class="dds__modal__header"><h3 class="dds__modal__title" id="modal-headline-160350263">Present new laptop</h3></div>
    <div id="modal-body-754450445" class="dds__modal__body">
      <p>
        Small, light, and stylish laptops and 2-in-1s designed for ultimate productivity. A new era of collaboration and connectivity to
        work anywhere. XPS laptops and 2-in-1s are precision crafted with premium materials, featuring stunning displays and the performance
        you demand to express your creative self and your big ideas.
        <a href="https://www.dell.com">dell.com</a>
      </p>
    </div>
    <div class="dds__modal__footer">
      <button class="dds__button dds__button--secondary dds__button--md" type="button" name="modal-primary-button">No</button>
      <button class="dds__button dds__button--md" type="button" name="modal-secondary-button">Yes</button>
    </div>
  </div>
</div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';

declare var DDS: any;
const modal= ref()
const list = ref(null)
onMounted(() => {
    modal.value = DDS.Modal(list.value);
})
</script>