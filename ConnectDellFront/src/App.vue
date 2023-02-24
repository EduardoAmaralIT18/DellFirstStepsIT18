
<template>
  <RouterView />
</template>

<script lang="ts">
import { defineComponent } from 'vue';
export default defineComponent({
  name: 'App',
  components: {
  }
});

</script>

<style>
#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.dds__modal--md {
  width: 400px;
}

.dds__modal__body p {
  text-align: left;
}

.buttonModal {
  width: 100%
}
</style>
