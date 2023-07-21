<template>
    <div class="dds__dropdown" data-dds="dropdown" ref="list" id="multi-select-list-dropdown" data-selection="multiple"
        data-select-all-label="Select all" @click="sendSelectedToParent">
        <div class="dds__dropdown__input-container">
            <label id="dropdown-label-331655468" for="dropdown-control-331655468" class="dds__label">{{ dropdownName
            }}</label>
            <div class="dds__dropdown__input-wrapper" autocomplete="off" aria-haspopup="listbox"
                aria-controls="multi-select-list-dropdown-popup">
                <input id="multi-select-list-dropdown-input" name="multi-select-list-dropdown-name" type="text"
                    role="combobox" class="dds__dropdown__input-field"
                    aria-labelledby="multi-select-list-dropdown-label multi-select-list-dropdown-helper" autocomplete="off"
                    aria-expanded="false" aria-controls="multi-select-list-dropdown-list" />
            </div>
        </div>
        <div id="multi-select-list-dropdown-popup" class="dds__dropdown__popup dds__dropdown__popup--hidden"
            role="presentation" tabindex="-1">
            <ul class="dds__dropdown__list" role="listbox" tabindex="-1" id="multi-select-list-dropdown-list">
                <li class="dds__dropdown__item" role="none" v-for="item in data" :key="item.id">
                    <button type="button" class="dds__dropdown__item-option" role="option" data-selected="false"
                        :data-value=item.id tabindex="-1">
                        <span class="dds__dropdown__item-label">{{ item.name }}</span>
                    </button>
                </li>
            </ul>
        </div>
    </div>
</template>

<script setup lang="ts">
import User from "@/interfaces/User"
import { ref, onMounted, PropType } from 'vue'

declare var DDS: any;
const list = ref(null)
const dropdown = ref();

onMounted(() => {
    dropdown.value = DDS.Dropdown(list.value)
})

const props = defineProps({
    dropdownName: String,
    data: Array as PropType<User[]>
})

function sendSelectedToParent() {
    const selected = dropdown.value.getSelection()
    const selectedId = []
    for (let item of selected) {
        selectedId.push(+item)
    }
    emits('ownerId', selectedId);
}

const emits = defineEmits({
    ownerId: Array
})
</script>