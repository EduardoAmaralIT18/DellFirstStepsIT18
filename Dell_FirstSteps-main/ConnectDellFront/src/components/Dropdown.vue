<template>
    <div class="dds__dropdown dds__dropdown--is-multiple" data-dds="dropdown" id="multi-select-list-dropdown" data-selection="multiple"
        data-select-all-label="Select all">
        <div class="dds__dropdown__input-container">
            <label id="dropdown-label-813077904" for="dropdown-control-813077904" class="dds__label">{{ boxName }}</label>
            <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox"
                aria-controls="multi-select-list-dropdown-popup">
                <input id="multi-select-list-dropdown-input" name="multi-select-list-dropdown-name" type="text"
                    role="combobox" class="dds__dropdown__input-field"
                    aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper" autocomplete="off"
                    aria-controls="multi-select-list-dropdown-list" />

                <small id="multi-select-list-dropdown-helper" class="dds__input-text__helper">Helper Text</small>
            </div>
        </div>
        <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dropdown__popup--hidden"
            role="presentation" tabindex="-1">
            <ul class="dds__dropdown__list" role="listbox" tabindex="-1" id="multi-select-list-dropdown-list">
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="1" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 1</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="2" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 2</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="3" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 3</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="4" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 4</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="5" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 5</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="6" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 6</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="7" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 7</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="8" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 8</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="9" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 9</span>
                    </button>
                </li>
                <li class="dds__dropdown__item" role="none">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        data-value="10" tabindex="-1">
                        <span class="dds__dropdown__item-label">List option 10</span>
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