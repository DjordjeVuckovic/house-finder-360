import '../upload-files.scss'
import {RiDeleteBin2Fill} from "react-icons/ri";
import {FileCardProps} from "../upload-files-props.ts";
export const FileCard= ({file,onDelete}: FileCardProps) => {
    return (
        <div className={'file-card'}>
            <div className={'flex-space white-text header-file-card'}>
                <p>{file.filename}</p>
                <div onClick={() => onDelete(file)} className={'delete-file'}>
                    <RiDeleteBin2Fill color={'#ff4040'}
                                      size={24}/>
                </div>
            </div>
            <img src={file.blob} alt={'file'}/>
        </div>
    );
};
