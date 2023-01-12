<template>
    <Multiselect mode="tags" :close-on-select="false" :searchable="true" :create-option="true"
        :options="[
            { value: 'batman', label: 'Batman' },
            { value: 'robin', label: 'Robin' },
            { value: 'joker', label: 'Joker' },
        ]" />
</template>

<script lang="ts">
import Multiselect from '@vueform/multiselect'


export default {
    components: {
        Multiselect,
    },
    data() {
        return {
            options: [
                'Batman',
                'Robin',
                'Joker',
            ]
        }
    }
}
</script>

<style src="@vueform/multiselect/themes/default.css">


</style>