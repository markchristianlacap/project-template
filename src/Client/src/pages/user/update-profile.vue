<script setup lang="ts">
import { type UserUpdateProfileReq, authApi } from '~/api/auth'

const userStore = useUserStore()
const toast = useToast()
const form = useForm<UserUpdateProfileReq>({} as UserUpdateProfileReq)
async function onSubmit() {
  await form.submit(async (fields) => {
    authApi.updateProfile(fields)
    toast.add({ severity: 'success', detail: 'Profile updated successfully' })
  })
}

onMounted(() => {
  if (userStore.user) {
    form.fields.name = userStore.user.name
    form.fields.email = userStore.user.email
  }
})
</script>

<template>
  <div class="mx-auto my-xl max-w-xl card">
    <h1 class="mb-sm text-xl">
      Update Profile
    </h1>
    <form @submit.prevent="onSubmit">
      <div class="flex flex-col gap-2">
        <label for="name">Name</label>
        <InputText v-model="form.fields.name" placeholder="Enter your email" />
        <small class="text-red-500">
          {{ form.errors.name }}
        </small>
      </div>
      <div class="flex flex-col gap-2">
        <label for="email">Email</label>
        <InputText v-model="form.fields.email" placeholder="Enter your email" />
        <small class="text-red-500">
          {{ form.errors.email }}
        </small>
      </div>
      <div class="mt-xl text-end">
        <Button label="Update Profile" icon="pi pi-user-edit" type="submit" />
      </div>
    </form>
  </div>
</template>
