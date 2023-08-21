export interface SelectItem {
    value: string | number;
    text: string;
}

export interface SelectItemsProps{
    defaultValue: SelectItem
    label: string;
    items: SelectItem[]
    selectedItemValue?: string | number
    register: any;
    mode?: string;
}