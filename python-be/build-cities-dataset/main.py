import json

import pandas as pd


def filter_dataset(countries: list):
    df = pd.read_csv('./dataset/worldcities.csv')
    filtered_df = df[df['country'].isin(countries)]
    filtered_df = filtered_df.drop(columns=['city', 'population', 'admin_name', 'capital'])
    filtered_df = filtered_df.rename(columns={'city_ascii': 'city'})
    filtered_df.to_csv('./dataset/filtered.csv', index=False)


def convert_to_json():
    filtered_df = pd.read_csv('./dataset/filtered.csv')
    json_data = filtered_df.to_dict(orient='records')
    with open('./json/filtered.json', 'w') as file:
        json.dump(json_data,file, indent=4)


def main():
    filter_dataset(['Serbia', 'Croatia', 'Macedonia', 'Bosnia and Herzegovina'])
    convert_to_json()


if __name__ == "__main__":
    main()
