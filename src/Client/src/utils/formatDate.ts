export function formatDate(date?: string, format = 'MMM DD, YYYY hh:mma') {
  if (!date)
    return ''
  const formatted = dayjs(date).format(format)
  return formatted
}
