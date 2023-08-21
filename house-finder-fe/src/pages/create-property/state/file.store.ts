import {create} from 'zustand';
import {FilePreview} from "../ui/upload-files-step/model/files.ts";
type FileState = {
    files: File[],
    previews: FilePreview[],
    addFiles: (files: File[]) => void,
    removeFile: (filename: string) => void,
    addPreviews: (previews: FilePreview[]) => void,
    removePreview: (filename: string) => void,
    clearStore: () => void
};
export const useFileStore = create<FileState>(set => ({
    files: [],
    previews: [],
    addFiles: (files) => set(state => ({ files: [...state.files, ...files] })),
    removeFile: (filename) => set(state => ({ files: state.files.filter(x => x.name !== filename) })),
    addPreviews: (previews) => set(state => ({ previews: [...state.previews, ...previews] })),
    removePreview: (filename) => set(state => ({ previews: state.previews.filter(x => x.filename !== filename) })),
    clearStore: () => set(_ => ({previews: [], files: []}))
}));