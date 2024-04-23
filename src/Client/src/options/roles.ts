import { Role } from '~/enums/role'
import type { IOption } from '~/types/option'

export const roles: IOption<Role>[] = [
  {
    label: 'Admin',
    value: Role.Admin,
  },
  {
    label: 'User',
    value: Role.User,
  },
]
