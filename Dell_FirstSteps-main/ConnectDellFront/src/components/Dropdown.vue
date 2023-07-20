<template>
    <div class="dds__dropdown" data-dds="dropdown" ref="list" id="multi-select-list-dropdown" data-selection="multiple" data-select-all-label="Select all">
  <div class="dds__dropdown__input-container">
    <label id="dropdown-label-331655468" for="dropdown-control-331655468" class="dds__label">Label</label>
    <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox" aria-controls="multi-select-list-dropdown-popup">
      <input
        id="multi-select-list-dropdown-input"
        name="multi-select-list-dropdown-name"
        type="text"
        role="combobox"
        class="dds__dropdown__input-field"
        aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper"
        autocomplete="off"
        aria-expanded="false"
        aria-controls="multi-select-list-dropdown-list"
      />

      <small id="multi-select-list-dropdown-helper" class="dds__input-text__helper">Helper Text</small>
    </div>
  </div>
  <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dropdown__popup--hidden" role="presentation" tabindex="-1">
    <ul class="dds__dropdown__list" role="listbox" tabindex="-1" id="multi-select-list-dropdown-list">
      <li class="dds__dropdown__item" role="none">
        <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false" data-value="1" tabindex="-1">
          <span class="dds__dropdown__item-label">List option 1</span>
        </button>
      </li>
      <li class="dds__dropdown__item" role="none">
        <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false" data-value="2" tabindex="-1">
          <span class="dds__dropdown__item-label">List option 2</span>
        </button>
      </li>
    </ul>
  </div>
</div>
</template>

<script setup lang="ts">

import{ ref, onMounted } from 'vue'

const list = ref(null)
declare var DDS: any;
onMounted(()=> DDS.Dropdown(list.value))

 

</script>
