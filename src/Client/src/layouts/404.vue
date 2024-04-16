<script setup lang="ts">
const router = useRouter()
</script>

<template>
  <main class="container mx-auto">
    <RouterView />
    <div class="flex items-center justify-center gap-2">
      <Button icon="pi pi-arrow-left" label="Go Back" @click="router.back()" />
      <RouterLink to="/">
        <Button icon="pi pi-home" label="Go to Home Page" />
      </RouterLink>
    </div>
  </main>
</template>
