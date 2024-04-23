export type Errors<T> = Partial<Record<keyof T | 'generalErrors', string[]>>
