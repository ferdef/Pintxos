# Generated by Django 4.0 on 2021-12-28 13:20

import django.core.validators
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('auth', '0012_alter_user_first_name_max_length'),
        ('pintxos', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='PintxoVote',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('value', models.IntegerField(validators=[django.core.validators.MaxValueValidator(10), django.core.validators.MinValueValidator(1)])),
                ('pintxo', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='pintxos.pintxo')),
                ('voter', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='auth.user')),
            ],
        ),
    ]
