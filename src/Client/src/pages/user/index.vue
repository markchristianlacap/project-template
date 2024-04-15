<script setup lang="ts">
const userStore = useUserStore()
const user = computed(() => userStore.user)
</script>

<template>
  <div>
    Hello, {{ user?.name }}
  </div>
</template>
