import json

import pandas as pd


def filter_dataset(countries: list):
    df = pd.read_csv('./dataset/worldcities.csv')
    filtered_df = df[df['country'].isin(countries)]
    filtered_df = filtered_df.drop(columns=['city', 'population', 'admin_name', 'capital'])
    filtered_df = filtered_df.rename(columns={'city_ascii': 'city'})
    filtered_df.to_csv('./dataset/filtered.csv', index=False)


def convert_to_json(path_csv, path_json):
    filtered_df = pd.read_csv(path_csv)
    json_data = filtered_df.to_dict(orient='records')
    with open(path_json, 'w') as file:
        json.dump(json_data, file, indent=4)


def filter_balkan():
    filter_dataset(['Serbia', 'Croatia', 'Macedonia', 'Bosnia and Herzegovina'])
    convert_to_json('./dataset/filtered.csv', './json/filtered.json')


def extract_countries():
    df = pd.read_csv('./dataset/worldcities.csv')
    countries = df['country'].unique()
    return countries


def write_countries_to_json(countries):
    with open('./json/countries.json', 'w') as file:
        json.dump(countries, file, indent=4)


def main():
    # filter_balkan()
    write_countries_to_json(extract_countries())


if __name__ == "__main__":
    main()
