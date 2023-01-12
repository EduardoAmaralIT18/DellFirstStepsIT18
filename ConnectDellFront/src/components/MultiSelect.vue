<script lang="ts">
    import Multiselect from 'vue-multiselect'
    import { ajaxFindCountry } from './countriesApi'

    export default {
    components: {
        Multiselect
    },
    data () {
        return {
        selectedCountries: [],
        countries: [],
        isLoading: false
        }
    },
    methods: {
        limitText (count) {
        return `and ${count} other countries`
        },
        asyncFind (query) {
        this.isLoading = true
        ajaxFindCountry(query).then(response => {
            this.countries = response
            this.isLoading = false
        })
        },
        clearAll () {
        this.selectedCountries = []
        }
    }
    }
</script>

<template>
    <div>
    <label class="typo__label" for="ajax">Async multiselect</label>
    <multiselect v-model="selectedCountries" id="ajax" label="name" track-by="code" placeholder="Type to search" open-direction="bottom" :options="countries" :multiple="true" :searchable="true" :loading="isLoading" :internal-search="false" :clear-on-select="false" :close-on-select="false" :options-limit="300" :limit="3" :limit-text="limitText" :max-height="600" :show-no-results="false" :hide-selected="true" @search-change="asyncFind">
        <template slot="tag" slot-scope="{ option, remove }"><span class="custom__tag"><span>{{ option.name }}</span><span class="custom__remove" @click="remove(option)">❌</span></span></template>
        <template slot="clear" slot-scope="props">
        <div class="multiselect__clear" v-if="selectedCountries.length" @mousedown.prevent.stop="clearAll(props.search)"></div>
        </template><span slot="noResult">Oops! No elements found. Consider changing the search query.</span>
    </multiselect>
    <pre class="language-json"><code>{{ selectedCountries  }}</code></pre>
    </div>
</template>