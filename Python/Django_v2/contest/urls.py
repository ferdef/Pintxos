from django.urls import path

from . import views

urlpatterns = [
    path("", views.index, name="index"),
    path("contest/<int:contest_id>/", views.contest_detail, name="contest_detail"),
    path("pintxo/<int:pintxo_id>/", views.pintxo_detail, name="pintxo_detail"),
    path("pintxos/", views.pintxos, name="pintxos"),
]