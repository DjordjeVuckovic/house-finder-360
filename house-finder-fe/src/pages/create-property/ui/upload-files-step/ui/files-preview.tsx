import {FileCard} from "./file-card.tsx";
import {NoItems} from "../../../../../core/no-items/no-items.tsx";
import houseImg from "../../../../../assets/pictures/no-house.png"
import {Typography} from "@mui/material";
import {Fragment} from "react";
import {FilesPreviewProps} from "../upload-files-props.ts";

export const FilesPreview = ({ files, onDeleteFile }: FilesPreviewProps) => {
    return (
        <Fragment>
            <Typography fontSize={25} fontWeight={700} color="#ffffff">
                Files preview
            </Typography>
            <Fragment>
                {
                    files.length === 0 ? (<NoItems
                        imgSrc={houseImg}
                        content={'You not uploaded files yet!'}
                        imgHeight={'200px'}
                        imgWidth={'200px'}
                        contentColor={'#4066ff'}
                        position={'center'}/>
                    ) :
                    (<div className={'grid-2-c'}>
                        {
                            files.map((file, index) =>
                            <FileCard
                            file={file}
                            key={index}
                            onDelete={onDeleteFile}
                            />
                            )
                        }
                    </div>)
                }
            </Fragment>
        </Fragment>
    );
};
