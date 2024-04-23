<script setup lang="ts">
const userStore = useUserStore()
const user = computed(() => userStore.user)
</script>

<template>
  <div class="mx-auto my-4 container card">
    <p class="text-sm">
      Hello, {{ user?.name }}
    </p>
  </div>
</template>
