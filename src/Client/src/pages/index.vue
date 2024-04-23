<script setup lang="ts">
import type { Errors } from '~/types/errors'

const userStore = useUserStore()
const loading = ref(false)
const router = useRouter()
const errors = ref<Errors<typeof form.value>>({})
const form = ref({
  email: '',
  password: '',
})
async function login() {
  try {
    loading.value = true
    errors.value = {}
    await userStore.login(form.value)
    router.push('/user')
  }
  catch (e: any) {
    errors.value = e?.response?.data?.errors || {}
  }
  loading.value = false
}
</script>

<template>
  <div class="grid h-screen justify-center grid-items-center">
    <form class="mx-sm max-w-500px md:mx-0" @submit.prevent="login">
      <Card>
        <template #title>
          <div class="flex items-center justify-between">
            <span>
              Login to your account
            </span>
            <Button :icon="isDark ? 'pi pi-moon' : 'pi pi-sun'" text @click="toggleDark()" />
          </div>
        </template>
        <template #subtitle>
          Please enter your email and password to login to your account.
        </template>
        <template #content>
          <Message v-if="errors.generalErrors" severity="error">
            {{ errors.generalErrors[0] }}
          </Message>
          <div class="flex flex-col gap-2">
            <label for="email">Email</label>
            <InputText v-model="form.email" placeholder="Enter your email" type="email" :invalid="!!errors.email" />
            <small v-if="!!errors.email" class="text-red-500">{{ errors.email[0] }}</small>
          </div>
          <div class="mt-sm flex flex-col gap-2">
            <label for="password">Password</label>
            <Password v-model="form.password" toggle-mask :feedback="false" placeholder="Enter your password" :invalid="!!errors.password" />
            <small v-if="!!errors.password" class="text-red-500">{{ errors.password[0] }}</small>
          </div>
          <div class="mt-xl text-end">
            <Button label="Login" :loading="loading" type="submit" />
          </div>
        </template>
      </Card>
    </form>
  </div>
</template>

<route lang="yaml">
meta:
  layout: home
  auth: guest
</route>
