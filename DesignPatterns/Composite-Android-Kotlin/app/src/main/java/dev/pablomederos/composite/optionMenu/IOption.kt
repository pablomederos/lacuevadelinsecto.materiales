package dev.pablomederos.composite.optionMenu

import androidx.compose.runtime.Composable

interface IOption {

    @Composable
    fun CreateOption()
    fun select(state: Boolean): List<String>
}