<script setup lang="ts">
import type { UserRowRes, UserStoreReq, UserUpdateReq } from '~/api/users'
import { usersApi } from '~/api/users'
import { Role } from '~/enums/role'

type IForm = UserStoreReq & UserUpdateReq
const { fetchRequest, loading, onSort, response, request } = useApiPagedReq(usersApi.getPaged)
const formDialog = ref(false)
const resetDialog = ref(false)
const form = ref<IForm>({} as IForm)
const id = ref<string>()
function create() {
  formDialog.value = true
  id.value = ''
  form.value = { email: '', name: '', password: '', isActive: true, role: Role.User }
}
function edit(data: UserRowRes) {
  id.value = data.id
  form.value = {
    email: data.email,
    isActive: data.isActive,
    name: data.name,
    role: data.role,
  } as IForm
  formDialog.value = true
}
function resetPassword(data: UserRowRes) {
  id.value = data.id
  resetDialog.value = true
}

onMounted(() => {
  fetchRequest()
})
watchDeep(request, () => {
  if (request.value.search)
    fetchRequest()
})
</script>

<template>
  <div class="mx-auto my-4 container card">
    <div class="mb-3 flex items-center justify-between">
      <p class="text-lg font-bold">
        User Management
      </p>
      <div class="flex gap-2">
        <InputText v-model="request.search" placeholder="Search users..." />
        <Button label="Create" @click="create()" />
      </div>
    </div>

    <DataTable
      :value="response?.rows"
      lazy
      :loading="loading"
      @sort="onSort"
    >
      <Column field="name" header="Name" class="text-nowrap" sortable>
        <template #editor="{ data, field }">
          <InputText v-model="data[field]" />
        </template>
      </Column>
      <Column field="email" header="Email" sortable class="text-nowrap" />
      <Column field="roleDesc" sort-field="role" header="Role" sortable class="text-nowrap" />
      <Column field="createdAt" sortable header="Created At" class="text-nowrap">
        <template #body="slotProps">
          {{ formatDate(slotProps.data.createdAt) }}
        </template>
      </Column>
      <Column field="updatedAt" sortable header="Updated At" class="text-nowrap">
        <template #body="slotProps">
          {{ formatDate(slotProps.data.updatedAt) }}
        </template>
      </Column>
      <Column field="isActive" sortable header="Status" class="text-nowrap">
        <template #body="{ data }">
          <InlineMessage :severity="data?.isActive ? 'success' : 'error'">
            {{ data?.isActive ? 'Active' : 'Inactive' }}
          </InlineMessage>
        </template>
      </Column>
      <Column field="actions" header="Actions" class="text-nowrap">
        <template #body="{ data }">
          <Button v-tooltip="`Edit User`" icon="pi pi-pencil" text @click="edit(data)" />
          <Button v-tooltip="`Reset Password`" icon="pi pi-refresh" text severity="danger" @click="resetPassword(data)" />
        </template>
      </Column>
    </DataTable>
    <Pagination v-model="request.page!" :total-pages="response?.rowsCount!" />

    <UserDialogForm :id="id" v-model:dialog="formDialog" v-model:form="form" @success="fetchRequest" />
    <UserResetDialogForm v-if="id" :id="id" v-model:dialog="resetDialog" @success="fetchRequest" />
  </div>
</template>
