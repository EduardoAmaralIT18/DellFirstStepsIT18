<script setup lang="ts">
import "@dds/components/src/scss/dds-icons.scss";
</script>

<template>
  <div class="dds__date-picker" data-dds="date-picker" id="startPicker">
    <label
      v-if="required"
      id="date-picker-label-206993451"
      for="date-picker-control-name-206993451"
      class="dds__label dds__label--required"
      >{{ boxName }}</label
    >
    <label
      v-else
      id="date-picker-label-206993451"
      for="date-picker-control-name-206993451"
      class="dds__label dds__label"
      >{{ boxName }}</label
    >
    <div class="dds__date-picker__wrapper">
      <input
        v-if="dateNow"
        type="date"
        class="dds__date-picker__input"
        placeholder="Enter the date"
        required="true"
        maxlength="256"
        id="date-picker-control-206993451"
        name="date-picker-control-name-206993451"
        aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451"
        v-model="preset"
        @input="sendStartToParent(preset)"
      />
      <input
        v-else
        type="date"
        class="dds__date-picker__input"
        placeholder="Enter the date"
        required="true"
        maxlength="256"
        id="date-picker-control-206993451"
        name="date-picker-control-name-206993451"
        aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451"
        v-model="info"
        @input="sendEndToParent(info)"
        :min="minRequired ? preset : undefined"
      />

      <!-- <input type="date" class="dds__date-picker__input" placeholder="Enter the date" required="true" maxlength="256"
                id="date-picker-control-206993451" name="date-picker-control-name-206993451"
                aria-labelledby="date-picker-label-206993451 date-picker-helper-206993451" :value="dateNow ? preset : info" :v-model="dateNow ? preset : info"
                @input="dateNow? sendStartToParent(preset) : sendEndToParent(info)" :min="minRequired ? preset : undefined"/> -->

      <small id="date-picker-helper-206993451" class="dds__date-picker__helper"
        >Please, use the format MM/DD/YYYY</small
      >
      <div
        id="date-picker-error-206993451"
        class="dds__date-picker__invalid-feedback"
      >
        Invalid date
      </div>
    </div>
  </div>
</template>

<script lang="ts">
export default {
  name: "DatePicker",
  data() {
    return {
      info: "",
      preset: new Date().toISOString().slice(0, 10),
    };
  },
  props: {
    boxName: String,
    required: Boolean,
    dateNow: Boolean,
    minRequired: Boolean,
    infoProps: String,
  },
  methods: {
    sendStartToParent(date: string) {
      this.preset = date;
      this.$emit("selectedDate", date);
    },
    sendEndToParent(date: Date) {
      this.info = date;
      this.$emit("selectedDate", date);
    },
  },
  mounted() {
    this.info = this.infoProps;
  },
};
</script>

<style scoped></style>
