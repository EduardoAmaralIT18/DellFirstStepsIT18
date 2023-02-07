<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  methods: {},
  props: {
    titleProp: {
      type: String,
    },
    descriptionProp:{
      type: String,
    },


  },
});
</script>

<template>

<link rel="stylesheet" href="style.css" />
<div class="wrapper">
  <a href="#demo-modal">Abrir modal</a>
</div>

<div id="demo-modal" class="modal">
  <div class="content">
    <h1>Program Created</h1>

    <p>
      Lorem Ipsum is simply dummy text of the printing and typesetting industry.
    </p>

    <div class="footer">
      <a href="#" class="footer-btn-close"> Fechar </a>
    </div>

    <a href="#" class="close">&times;</a>
  </div>
</div>

</template>

<style scoped>

.wrapper {
  height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
}

.wrapper a {
  display: inline-block;
  text-decoration: none;
  padding: 15px;
  background-color: #fff;
  border-radius: 3px;
  text-transform: uppercase;
  color: #585858;
  font-family: "Roboto", sans-serif;
}

.modal {
  visibility: hidden;
  opacity: 0;
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  background: rgba(77, 77, 77, 0.7);
  transition: all 0.4s;
}

.modal:target {
  visibility: visible;
  opacity: 1;
}

.content {
  border-radius: 4px;
  position: relative;
  width: 500px;
  max-width: 90%;
  background: #fff;
  padding: 1em 2em;
}

.footer {
  text-align: right;
  margin-top: 50px;
}

.close {
  position: absolute;
  top: 10px;
  right: 10px;
  color: #585858;
  text-decoration: none;
}

.footer-btn-close {
  width: 150px;
  padding: 10px;
  text-decoration: none;
  background-color: #cfcca8;
  color: #000000;
  border-radius: 3px;
}
</style>
