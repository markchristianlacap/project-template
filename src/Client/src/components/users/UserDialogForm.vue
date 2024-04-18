<script setup lang="ts">
const { visible, form } = defineModels<{
  visible: boolean
  form: any
}>()
const toast = useToast()
const loading = ref(false)
const errors = ref<Record<string, string[]>>({})
async function submit() {
  try {
    loading.value = true
    if (!form.value.id)
      await api.post('/users', form.value)

    else
      await api.put(`users/${form.value.id}`, form.value)
    toast.add({ detail: 'User saved successfully', severity: 'success' })
  }
  catch (e: any) {
    errors.value = e ? e.response.data.errors : {}
  }
  loading.value = false
}
watch(visible, () => {
  if (visible) {
    form.value = {}
    errors.value = {}
  }
})
</script>

<template>
  <Dialog v-model:visible="visible" modal header="User Form">
    <form @submit.prevent="submit">
      <div class="mb-3 flex flex-col gap-3">
        <label for="name">Name</label>
        <InputText v-model="form.name" placeholder="Enter user name" />
        <small v-if="errors.name" class="text-red-500">
          {{ errors.name[0] }}
        </small>
      </div>
      <div class="mb-3 flex flex-col gap-3">
        <label for="email">Email</label>
        <InputText v-model="form.email" placeholder="Enter user email" />
        <small v-if="errors.email" class="text-red-500">
          {{ errors.email[0] }}
        </small>
      </div>
      <div class="mb-3 flex flex-col gap-3">
        <label for="password">Password</label>
        <Password v-model="form.password" type="password" placeholder="Enter user password" />
        <small v-if="errors.password" class="text-red-500">
          {{ errors.password[0] }}
        </small>
      </div>
      <div class="mt-10 flex justify-end gap-2">
        <Button label="Cancel" severity="danger" @click="visible = false" />
        <Button type="submit" label="Submit" :loading="loading" />
      </div>
    </form>
  </Dialog>
</template>
