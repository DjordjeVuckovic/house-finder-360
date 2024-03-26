import { useState } from 'react'
import './upload-photos.scss'
import uploadPhoto from '../../../../assets/pictures/upload.png'
import { LiaFileUploadSolid } from 'react-icons/lia'
import { Typography } from '@mui/material'
import { FilesPreview } from './ui/files-preview.tsx'
import { FilePreview } from './model/files.ts'
import { useFileStore } from '../../state/file.store.ts'
import { ButtonWithIcon } from '../../../../shared/ui/buttons'
import { MdNavigateBefore, MdOutlineNavigateNext } from 'react-icons/md'
export const UploadPhotosStep = ({ type, onBack, onNext }) => {
  const [dragging, setDragging] = useState(false)
  const { files, previews, addFiles, removeFile, addPreviews, removePreview } =
    useFileStore()

  const handleDragEnter = (e) => {
    preventDefaultAndStopPropagation(e)
    setDragging(true)
  }

  const handleDragLeave = (e) => {
    preventDefaultAndStopPropagation(e)
    setDragging(false)
  }

  const handleDragOver = (e) => preventDefaultAndStopPropagation(e)
  const onDeleteFile = (e: FilePreview) => {
    removePreview(e.filename)
    removeFile(e.filename)
  }

  const handleDrop = (e) => {
    setDragging(false)
    const filesArray = [...e.dataTransfer.files]
    addFiles(filesArray)
    handlePreviewFiles(filesArray)
  }
  const preventDefaultAndStopPropagation = (e) => {
    e.preventDefault()
    e.stopPropagation()
  }
  const handlePreviewFiles = (filesUpload) => {
    const previewsArray: FilePreview[] = filesUpload.map((file) => {
      const filePreview: FilePreview = {
        filename: file.name,
        blob: URL.createObjectURL(file),
      }
      return filePreview
    })
    addPreviews(previewsArray)
  }
  const handleFileChange = (e) => {
    const fileArray = [...e.target.files]
    addFiles(fileArray)
    handlePreviewFiles(fileArray)
  }
  return (
    <div
      style={{
        display: 'flex',
        flexDirection: 'column',
        gap: '1.2rem',
      }}
    >
      <Typography fontSize={25} fontWeight={700} color='#ffffff'>
        {type} a Property <span className={'step-count'}>(upload images)</span>
      </Typography>
      <div
        className={dragging ? 'drag-area dragging' : 'drag-area'}
        onDragEnter={handleDragEnter}
        onDragLeave={handleDragLeave}
        onDragOver={handleDragOver}
        onDrop={handleDrop}
        onChange={handleFileChange}
      >
        <img src={uploadPhoto} alt={'uploadPhoto'} />
        <p>Drag and drop files here, or click to select files</p>
        <div className={'file-uploader'}>
          <input
            type='file'
            className={'file-input'}
            id={'fileInput'}
            multiple
          />
          <label htmlFor='fileInput'>
            Choose Files
            <LiaFileUploadSolid color={'#ff922d'} size={24} />
          </label>
        </div>
        <div className={'flex-start flex-wrap g-07 p-top-1'}>
          {' '}
          {files.map((file, index) => (
            <p key={index}>
              <span className={'file-index'}>{index})</span>
              {file.name}
            </p>
          ))}
        </div>
      </div>
      <FilesPreview files={previews} onDeleteFile={onDeleteFile} />
      <div className={'btn-group'}>
        <ButtonWithIcon
          bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
          color={'#f5f8f2'}
          icon={MdNavigateBefore}
          width={'20%'}
          onClick={onBack}
        >
          Back
        </ButtonWithIcon>
        <ButtonWithIcon
          bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
          color={'#f5f8f2'}
          icon={MdOutlineNavigateNext}
          width={'20%'}
          iconFirst={false}
          onClick={onNext}
        >
          Next
        </ButtonWithIcon>
      </div>
    </div>
  )
}
