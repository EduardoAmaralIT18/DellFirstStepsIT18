<template>
    <div class="dds__dropdown dds__dropdown--is-multiple" data-dds="dropdown" id="multi-select-list-dropdown"
        data-selection="multiple" data-select-all-label="Select all">
        <div class="dds__dropdown__input-container">
            <label id="dropdown-label-450306425" for="dropdown-control-450306425" class="dds__label">{{ boxName }}</label>
            <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox"
                aria-controls="multi-select-list-dropdown-popup">
                <input id="multi-select-list-dropdown-input" type="text"
                    role="combobox" class="dds__dropdown__input-field"
                    aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper" autocomplete="off"
                    aria-controls="multi-select-list-dropdown-list" aria-describedby="dropdown-tag-662301920"/>
            </div>
        </div>
        <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dynamic-dropdown__popup--hidden"
            role="presentation" tabindex="-1">
            <ul class="dds__dropdown__list" role="listbox" tabindex="-1" id="multi-select-list-dropdown-list">
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        tabindex="-1" data-value="1">
                        <span class="dds__dropdown__item-label">Name</span>
                    </button>
                </li>
            </ul>
        </div>
    </div>
</template>

<script setup lang="ts">

const props = defineProps({
    boxName: String
});

</script>

<style scoped></style>