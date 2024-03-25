import { FilePreview } from './model/files.ts'

export interface FilesPreviewProps {
  files: FilePreview[]
  onDeleteFile: any
}
export interface FileCardProps {
  file: FilePreview
  onDelete: any
}
