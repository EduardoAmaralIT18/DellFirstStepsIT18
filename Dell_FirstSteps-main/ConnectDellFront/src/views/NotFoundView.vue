<script setup lang="ts">

</script>

<template>
  <div class="container">
    <div class="content">
      <span>ERROR 404</span>
      <h1 class="dds__mt-3 dds__mb-3">
        Page Not Found
      </h1>
      <div>
        <p class="dds__body-1 dds__mb-5 dds__pb-3">
          We can't show the page you wanted to see here. We're sorry about that.
        </p>
        <RouterLink id="routerLink" to="/home">
          Go to our home page
        </RouterLink>
      </div>
    </div>
    <img src="../assets/notFound.png" alt="">
  </div>
</template>

<style scoped>
.container {
  margin-left: 20%;
  margin-right: 20%;
  padding-top: 70px;
  display: flex;
  flex-direction: row;
}

.content{
  margin-top: 3.9rem;
}

#routerLink{
  text-decoration: none;
}

</style>