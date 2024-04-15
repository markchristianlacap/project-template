<script setup lang="ts">
import Toast from 'primevue/toast'
// https://github.com/vueuse/head
// you can use this to manipulate the document head in any components,
// they will be rendered correctly in the html results with vite-ssg
useHead({
  title: 'Occidental Mindoro State College',
  meta: [
    {
      name: 'description',
      content: 'Occidental Mindoro State College is a public university located in Occidental Mindoro, Philippines.',
    },
    {
      name: 'theme-color',
      content: () => isDark.value ? '#00aba9' : '#ffffff',
    },
  ],
  link: [
    {
      rel: 'icon',
      type: 'image/svg+xml',
      href: () => preferredDark.value ? '/favicon.ico' : '/favicon.ico',
    },
  ],
})
</script>

<template>
  <Toast />
  <RouterView />
</template>
