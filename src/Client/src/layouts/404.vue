<script setup lang="ts">
const router = useRouter()
</script>

<template>
  <main class="container">
    <RouterView />
    <div class="flex items-center justify-center gap-2">
      <Button>
        <RouterLink to="/">
          Go to Home
        </RouterLink>
      </Button>
      <Button @click="router.back()">
        Go back
      </Button>
    </div>
  </main>
</template>
