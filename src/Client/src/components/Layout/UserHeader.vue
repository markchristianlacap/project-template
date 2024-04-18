<script setup lang="ts">

</script>

<template>
  <div class="flex items-center justify-between px-3 py-2">
    <div>
      <p class="text-surface-600 font-bold dark:text-surface-300">
        Admin Panel
      </p>
    </div>
    <Button :icon="`pi ${isDark ? 'pi-sun' : 'pi-moon'}`" text @click="toggleDark()" />
  </div>
</template>
